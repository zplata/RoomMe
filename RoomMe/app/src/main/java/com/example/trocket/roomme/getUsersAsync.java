package com.example.trocket.roomme;

import android.os.AsyncTask;

import java.util.ArrayList;

/**
 * Created by Billy on 7/17/15.
 */
public class getUsersAsync extends AsyncTask<Integer, Void, ArrayList<User>> {

    HomeActivity home;
    public getUsersAsync(HomeActivity home) {
        this.home = home;
    }

    //doInBackground is the method called when a JsonAccessor.execute("url") is called
    @Override
    protected ArrayList<User> doInBackground(Integer...params)
    {
        try{
            //urls[0] is the first argument given, in this case it is the URL to be accessed
            String derp = JsonAccessor.getJSON("http://roomme.azurewebsites.net/Api/user");

            ArrayList<User> userList = JsonParser.parseJSONForUsers(derp);
            //System.out.println(derp);
            return userList;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    protected void onPostExecute(ArrayList<User> result)
    {
        home.getUsersResponse(result);
    }

}

