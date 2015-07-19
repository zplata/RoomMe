package com.example.trocket.roomme;

import android.os.AsyncTask;

import java.util.ArrayList;

/**
 * Created by Billy on 7/17/15.
 */
public class getUsersAsync extends AsyncTask<Integer, Void, ArrayList<User>> {

    HomeActivity home;
    HomeFragment homeF;
    int selected;
    public getUsersAsync(HomeActivity home) {
        this.home = home;
    }
    public getUsersAsync(HomeFragment home) { this.homeF = home; }


    //doInBackground is the method called when a JsonAccessor.execute("url") is called
    @Override
    protected ArrayList<User> doInBackground(Integer...params)
    {
        try{
            if ( params[0] == 1)
            {
                selected =1;
            }
            else if ( params[0] == 2)
            {
                selected =2;
            }
            else
            {
                selected = 999;
            }
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
        switch (selected) {
            case 1:
                home.getUsersResponse(result);
                break;
            case 2:
                homeF.getUsersResponse(result);
                break;
            default:
                break;
        }
    }

}

