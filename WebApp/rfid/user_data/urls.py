from django.conf.urls import url

from . import views

urlpatterns = [
    url(r'^(?P<uuid>\d+)', views.data, name='data'),
    url(r'^all/', views.all, name='all'),
]