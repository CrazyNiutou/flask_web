# -*- coding: utf-8 -*-
from flask import Flask, render_template
from flaskr import db
from flaskr import config
import datetime

app = Flask(__name__)
app.config.from_object(config.DevConfig)
try:
    db.get_session()

    # 注册蓝图
    from flaskr import auth

    app.register_blueprint(auth.bp)
    if __name__ == 'flasker':
        app.run(debug=True)
except Exception as e:
    print(e)


@app.route('/index')
@app.route('/')
def index():
    try:
        # time = datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S')
        # entity = db.UserEntity(
        #     # id='11',
        #     userId='1',
        #     userName='1',
        #     pwd='1',
        #     email='1',
        #     create_time=time)
        # session = db.get_session()
        # dbbase = session()
        # dbbase.add(entity)
        # dbbase.commit()
        # return 'helloWorld'
        return render_template('home/index.html',title='首页')
    except Exception as e:
        print(e)
