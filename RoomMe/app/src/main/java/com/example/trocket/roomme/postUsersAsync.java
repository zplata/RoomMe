package com.example.trocket.roomme;

import android.os.AsyncTask;

import org.json.JSONObject;

import java.util.ArrayList;

/**
 * Created by Billy on 7/19/15.
 */
public class postUsersAsync extends AsyncTask<JSONObject, Void, User > {

    InitialProfileEdit edit;
    public postUsersAsync(InitialProfileEdit edit) {
        this.edit = edit;
    }

    @Override
    protected User doInBackground(JSONObject...params)
    {
        try{
            //params[0] is the first argument given, in this case it is the User to be posted
            return JsonPoster.postJSON(params[0]);
        }
        catch(Exception e)
        {
            e.printStackTrace();
            return null;
        }
    }
    protected void onPostExecute(User user)
    {
                edit.onUserIdReturned(user);
    }
}


