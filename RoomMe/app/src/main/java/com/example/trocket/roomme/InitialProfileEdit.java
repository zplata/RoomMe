package com.example.trocket.roomme;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;

import org.json.JSONException;
import org.json.JSONObject;


public class InitialProfileEdit extends ActionBarActivity {

    private JSONObject obj;
    private Spinner status;
    private EditText phoneNum;
    private EditText age;
    private Button submit;
    private String statusOfficial;
    private int statusPosition;

    postUsersAsync postInitialUser;

    String[] items = {
            "Has vacancy",
            "Needs housing and roommate",
            "Only need roommate(s)",
            "Inactive"
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_initial_profile_edit);

        statusPosition = 0;
        statusOfficial = "Has vacancy";
        status = (Spinner) findViewById(R.id.aipe_edit_status);
        phoneNum = (EditText) findViewById(R.id.aipe_edit_phone);
        submit = (Button) findViewById(R.id.aipe_submit);
        age = (EditText) findViewById(R.id.aipe_edit_age);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getApplicationContext(),
                R.layout.spinner_item, items);
        adapter.setDropDownViewResource(R.layout.spinner_item);
        status.setAdapter(adapter);
        status.setSelection(0);
        status.setOnItemSelectedListener(new SpinnerItemSelected());

        try {
            obj = new JSONObject(getIntent().getStringExtra("JsonObject"));

        } catch (JSONException e) {
            e.printStackTrace();
        }

        submit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
               statusOfficial = items[statusPosition];
                try {
                    obj.put("phoneNumber", phoneNum.getText());
                    obj.put("status", statusOfficial);
                    obj.put("age", age.getText());
                    postInitialUser = new postUsersAsync(InitialProfileEdit.this);
                    // Note: THIS IS WHERE YOU POST JSON OBJECT TO PARSER
                    postInitialUser.execute(obj);
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
        });

    }



    private class SpinnerItemSelected implements AdapterView.OnItemSelectedListener {

        @Override
        public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
            statusPosition = position;
        }

        @Override
        public void onNothingSelected(AdapterView<?> parent) {

        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_initial_profile_edit, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    /*public void onUserIdReturned(User pass) {
        SharedPreferences prefs = PreferenceManager.getDefaultSharedPreferences(this);
        SharedPreferences.Editor editor = prefs.edit();
        editor.putInt("user_id", pass.getUserID());
        editor.putString("user_name", pass.getName());
        String s = pass.getGender();
        int g = 0;
        if(s.equals("F")) {
            g = 1;
        }
        editor.putInt("user_gender", g);
        editor.putInt("user_age", pass.getAge());
        editor.putString("user_phone", pass.getPhoneNumber());
        editor.putString("user_email", pass.getEmail());
        String tempS = pass.getStatus();
        int st = 0;
        if(tempS.equals("Has vacancy")) {
            st = 0;
        }
        else if (tempS.equals("Needs housing and roommate")) {
            st = 1;
        }
        else if (tempS.equals("Only need roommate(s)")) {
            st = 2;
        }
        else {
            st = 3;
        }
        editor.putInt("user_status", st);
        editor.putString("user_housing_price", pass.getHousingPrice() + "");
        editor.putString("user_bio", pass.getBio());*/

    public void onUserIdReturned(User user) {
        /*SharedPreferences prefs = PreferenceManager.getDefaultSharedPreferences(this);
        SharedPreferences.Editor editor = prefs.edit();
         int user_id = user.getUserID();
        editor.putInt("user_id", user_id);
        editor.commit();*/
        HoldMyUserObject.my_user_object = user;

        int id = user.getUserID();
        SharedPreferences preferences = getSharedPreferences("user", Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = preferences.edit();
        editor.putInt("id", id );
        editor.commit();

        Intent i = new Intent(this, HomeActivity.class);
        startActivity(i);
    }
}
