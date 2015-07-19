package com.example.trocket.roomme;


import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

/**
 * Created by Billy on 7/16/15.
 * This JsonParser returns an ArrayList of users
 */
public class JsonParser {

    public static ArrayList<User> parseJSONForUsers(String input)
    {
        try
        {
            ArrayList<User> list = new ArrayList<User>();
            JSONArray jsonArray = new JSONArray(input);

            for (int i=0; i < jsonArray.length(); i++)
            {
                JSONObject user = jsonArray.getJSONObject(i);
                String tempName = null;
                String tempAge = null;
                tempName = user.optString("Name").toString();
                tempAge = user.optString("Age").toString();
                System.out.println("User Number: " + i + " Name: " + user.optString("Name").toString() + " Age: " + user.optString("Age").toString());
                if ( tempName != null && tempAge != null)
                {
                    User tempUser = new User(tempName, Integer.parseInt(tempAge));
                    list.add(tempUser);
                }
            }
            return list;

        }catch (JSONException e)
        {
            e.printStackTrace();
        }
        return null;
    }

    public static void parseJSONForCareers(String input)
    {

    }

    public static void parseJSONForLocations(String input)
    {

    }

}
