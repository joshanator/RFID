from django.shortcuts import render
import requests
import json

# Create your views here.
def data(request, uuid):
    url = u'http://rfid-api.azurewebsites.net/api/soldier?sid=' + uuid + "&val='1'"

    response = requests.get(url)
    json_data = json.loads(response.content)

    return render(request, 'user_data/index.html', {
        'json_data':json.dumps(json_data)
    })

def all(request):
    url = u'http://rfid-api.azurewebsites.net/api/soldier?val="a"'

    response = requests.get(url)
    json_data = json.loads(response.content)

    return render(request, 'user_data/all.html', {
        'json_data':json.dumps(json_data)
    })