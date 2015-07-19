package com.example.trocket.roomme;


import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.List;

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
                String tempName, tempAge, tempID, tempGender, tempPhone, tempEmail, tempStatus, tempHousingPrice, tempBio = null;
                //JSONArray jsonFavorites = new JSONArray(user.optJSONArray("FavoritedUserID's"));
                tempName = user.optString("Name").toString();
                tempAge = user.optString("Age").toString();
                tempID = user.optString("$id").toString();
                tempGender = user.optString("Gender").toString();
                tempPhone = user.optString("PhoneNumber").toString();
                tempEmail = user.optString("Email").toString();
                tempStatus = user.optString("Status").toString();
                //tempHousingPrice = user.optString("HousingPrice").toString();
                tempBio = user.optString("Bio").toString();
                List<Integer> tempFavorites = new ArrayList<Integer>();


                //System.out.println("User Number: " + i + " Name: " + user.optString("Name").toString() + " Age: " + user.optString("Age").toString() + " Phone: " + user.optString("PhoneNumber").toString()+ " Gender: " + user.optString("Gender").toString()+ " Bio: " + user.optString("Bio").toString());
                if ( tempName != null && tempAge != null && tempID != null && tempGender != null && tempStatus !=null && tempPhone!=null && tempEmail !=null  && tempBio !=null)
                {
                    //User tempUser = new User(tempName, Integer.parseInt(tempAge));
                    User tempUser = new User(Integer.parseInt(tempID), tempName, Integer.parseInt(tempGender), Integer.parseInt(tempAge),
                            tempPhone, tempEmail, Integer.parseInt(tempStatus), Double.parseDouble("0"), tempBio, tempFavorites);
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
