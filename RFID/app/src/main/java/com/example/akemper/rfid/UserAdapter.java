package com.example.akemper.rfid;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;

/**
 * Created by AKEMPER on 7/21/2017.
 */

public class UserAdapter extends ArrayAdapter<String> {

    public UserAdapter(Context context, ArrayList<SoldierDataField> users)
    {
        super(context, 0,users);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent)
    {
        // Get the data item for this position
        //SoldierDataField user = new SoldierDataField();
       //user.key = getItem(position);

        // Check if an existing view is being reused, otherwise inflate the view
        if (convertView == null)
        {
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.user_adapter, parent, false);
        }

        // Lookup view for data population
        TextView soldierName = (TextView) convertView.findViewById(R.id.variableView);
        TextView soldierPhoneNumber = (TextView) convertView.findViewById(R.id.resultView);
        // Populate the data into the template view using the data object
        soldierName.setText(key);
        soldierPhoneNumber.setText(value);
        // Return the completed view to render on screen
        return convertView;

        for ()
    }
}
