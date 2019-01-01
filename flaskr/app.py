from flask import Flask

app = Flask(__name__)


@app.route('/')
def hello_world():
    return 'hello 1'


@app.route('/user/<username>')
def show_user_profile(username):
    return 'User %s' % username
