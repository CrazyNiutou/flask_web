import datetime

from flask import (Blueprint, request, flash, redirect, url_for, session)
from flask.templating import render_template
from werkzeug.security import generate_password_hash

from flaskr import db

bp = Blueprint('auth', __name__, url_prefix='/auth')


@bp.route('/register', methods=('GET', 'POST'))
def register():
    if request.method == 'POST':
        userName = request.form['username']
        pwd = request.form['password']
        error = None
        result = None
        if not userName:
            error = '请输入用户名'
        elif not pwd:
            error = '请输入密码'
        else:
            Session = db.get_session()
            db_session = Session()
            result = db_session.query(
                db.UserEntity).filter_by(userId='11').first()
            if not result:
                error = '用户名已存在'
        if error is None:
            time = datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S')
            pwd = generate_password_hash(pwd)
            entity = db.UserEntity(
                # id='11',
                userId=userName,
                userName=userName,
                pwd=pwd,
                email='',
                create_time=time)
            Session = db.get_session()
            db_session = Session()
            db_session.add(entity)
            db_session.commit()
            return redirect(url_for('auth.login'))
        flash(error)
    return render_template('auth/register.html')


@bp.route('/login', methods=['GET', 'POST'])
def login():
    if request == 'POST':
        userName = request.form['username']
        pwd = request.form['password']
        error = None
        result = None
        if not userName:
            error = '请输入用户名'
        elif not pwd:
            error = '请输入密码'
        else:
            Session = db.get_session()
            db_session = Session()
            result = db_session.query(db.UserEntity).filter_by(userId=userName,
                                                               pwd=generate_password_hash(pwd)).first()
            if result is None:
                error = '用户名或密码不正确'
        if error is None:
            session.clear()
            session['user_id'] = result['userId']
            return redirect(url_for('index'))
        flash(error)
    return render_template('auth/login.html')
