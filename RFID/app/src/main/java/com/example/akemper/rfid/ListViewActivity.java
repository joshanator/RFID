package com.example.akemper.rfid;

import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Iterator;

/**
 * Created by AKEMPER on 7/21/2017.
 */

public class ListViewActivity extends AppCompatActivity{

    String urlSoldier = "http://rfid-api.azurewebsites.net/api/soldier?SID=3";
    String urlCondition = "http://rfid-api.azurewebsites.net/api/condition?SID=3";
    String urlAllergy = "http://rfid-api.azurewebsites.net/api/allergy?SID=3";
    String urlVacc = "http://rfid-api.azurewebsites.net/api/vaccination?SID=3";
    String urlMeds = "http://rfid-api.azurewebsites.net/api/medication?SID=3";
    public ListView list;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.list_view);



    }



private class GetInfo extends AsyncTask<Void, Void, Void> {

    // Hashmap for ListView
    ArrayList<SoldierDataField> studentList;

    @Override
    protected Void doInBackground(Void... arg0) {
// Creating service handler class instance
        WebRequest webreq = new WebRequest();

// Making a request to url and getting response
        String jsonStr = webreq.makeWebServiceCall(url, WebRequest.GETRequest);

        Log.d("Response: ", "> " + jsonStr);

        studentList = ParseJSON(jsonStr);

        return null;
    }

    @Override
    protected void onPostExecute(Void requestresult) {
        super.onPostExecute(requestresult);
/**
 * Updating received data from JSON into ListView
// * */
//        ListAdapter adapter = new SimpleAdapter(
//                MainActivity.this, studentList,
//                R.layout.list_item, new String[]{TAG_STUDENT_NAME, TAG_EMAIL,
//                TAG_STUDENT_PHONE_MOBILE}, new int[]{R.id.name,
//                R.id.email, R.id.mobile});

      //  setListAdapter(adapter);
    }

}
    private ArrayList<SoldierDataField> ParseJSON(String json) {
        if (json != null) {
            try {
// Hashmap for ListView
                ArrayList<SoldierDataField> Soldier = new ArrayList<SoldierDataField>();

                JSONObject jsonObj = new JSONObject(json);

// Getting JSON Array node
               // JSONArray students = jsonObj.getJSONArray(json);
                JSONArray soldiers = new JSONArray(json);
// looping through All Students
                for (int i = 0; i < soldiers.length(); i++) {
                    JSONObject c = soldiers.getJSONObject(i);

                    Iterator<String> Keys = c.keys();

                    while(Keys.hasNext()) {
                        SoldierDataField currentDAtaType = new SoldierDataField();
                        currentDAtaType.key = (String)Keys.next();


                         currentDAtaType.value = (String) c.get(currentDAtaType.key);
                        Soldier.add(currentDAtaType);
                    }
                }
               ArrayAdapter adapter = new UserAdapter(getApplicationContext(), Soldier);
                adapter.notifyDataSetChanged();
                adapter.setNotifyOnChange(true);
                list.setAdapter(adapter);

                return Soldier;
            } catch (JSONException e) {
                e.printStackTrace();
                return null;
            }
        } else {
            Log.e("ServiceHandler", "No data received from HTTP Request");
            return null;
        }
    }
}
