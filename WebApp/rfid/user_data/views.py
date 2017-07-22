from django.shortcuts import render
import requests
import json

# Create your views here.
def data(request, uuid):
    url = u'http://rfid-api.azurewebsites.net/api/soldier?sid=' + uuid

    response = requests.get(url)
    json_data = json.loads(response.content)

    return render(request, 'user_data/index.html', {
        'json_data':json.dumps(json_data)
    })
