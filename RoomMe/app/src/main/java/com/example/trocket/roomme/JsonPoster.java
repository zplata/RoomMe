package com.example.trocket.roomme;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.json.JSONObject;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;


/**
 * Created by Billy on 7/19/15.
 */
public class JsonPoster {

    public static User postJSON(JSONObject user)
    {
        HttpClient httpclient = new DefaultHttpClient();
        //String trimName = user.getName();

        String tempName, tempAge, tempID, tempGender, tempPhone, tempEmail,tempStatus, tempBio, tempAuth = null;
        //JSONArray jsonFavorites = new JSONArray(user.optJSONArray("FavoritedUserID's"));
        tempName = user.optString("name").toString();
        tempAge = user.optString("age").toString();
        tempBio = user.optString("bio").toString();
        tempGender = user.optString("gender").toString();
        tempStatus = user.optString("status").toString();
        tempPhone = user.optString("phoneNumber").toString();
        tempEmail = user.optString("email").toString();
        tempAuth = user.optString("id").toString();
        User tempUser;

        String splitStr[] = tempName.split("\\s+");
        tempName = splitStr[0];
        for ( int i = 1; i < splitStr.length; i++)
        {
            tempName += "+" + splitStr[i];
        }
        int gender = 1;
        switch (tempGender)
        {
            case "male" : gender = 0;
                break;
            default: gender = 1;
        }
        int status = 3;
        switch (tempStatus)
        {
            case "Has vacancy" : status = 0;
                break;
            case "Needs housing and roommate" : status = 1;
                break;
            case "Only need roommate(s)" : status = 2;
                break;
            default: status = 3;
                break;
        }


        String userUrl = "http://roomme.azurewebsites.net/Api/account/register/?email=" + tempEmail +
                "&name=" + tempName + "&age=" + tempAge + "&gender=" + gender + "&phone=" + tempPhone + "&authToken=" + tempAuth + "";
        HttpPost httpPost = new HttpPost(userUrl);

        try {


            // Execute HTTP Post Request
            HttpResponse response = httpclient.execute(httpPost);
            HttpEntity entity = response.getEntity();
            String result = EntityUtils.toString(entity);
            System.out.println(result);

            if ( tempName != null && tempAge != null && result != null && tempGender != null && tempStatus !=null && tempPhone!=null && tempEmail !=null  && tempBio !=null)
            {
                //User tempUser = new User(tempName, Integer.parseInt(tempAge));
                List<Integer> tempFavorites = new ArrayList<Integer>();
                tempUser = new User(Integer.parseInt(result), tempName, gender, Integer.parseInt(tempAge), tempPhone, tempEmail, status, 0.00, tempBio, tempFavorites);

                return tempUser;
            }


        } catch (ClientProtocolException e) {
            // TODO Auto-generated catch block
        } catch (IOException e) {
            // TODO Auto-generated catch block
        }
        return null;
    }
}
