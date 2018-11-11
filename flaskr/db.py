from sqlalchemy import create_engine
from sqlalchemy import Integer, String, DateTime, Column
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
from flaskr import config
import datetime

Base = declarative_base()
engine = create_engine(config.DevConfig.SQLALCHEMY_DATABASE_URI, echo=True)
# echo=True显示每条执行的SQL
DBSession = sessionmaker(bind=engine)


def get_session():
    # Base.metadata.create_all(engine)
    return DBSession


class UserEntity(Base):
    __tablename__ = 'users'
    id = Column(Integer, autoincrement=True, primary_key=True)
    userId = Column(String(20), unique=True, nullable=False)
    userName = Column(String(20), unique=True, nullable=False)
    pwd = Column(String(25), nullable=False)
    email = Column(String(30))
    create_time = Column(DateTime, default=datetime.time)
    status = Column(Integer, default=0)

    def __repr__(self):
        return self.id
