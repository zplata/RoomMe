package com.example.trocket.roomme;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import java.io.IOException;


/**
 * Created by Billy on 7/19/15.
 */
public class JsonPoster {

    public static Boolean postJSON( User user)
    {
        HttpClient httpclient = new DefaultHttpClient();
        String trimName = user.getName();
        String splitStr[] = trimName.split("\\s+");
        trimName = splitStr[0];
        for ( int i = 1; i < splitStr.length; i++)
        {
            trimName += "+" + splitStr[i];
        }


        String userUrl = "http://roomme.azurewebsites.net/Api/account/register/?email=" + user.getEmail() +
                "&name=" + trimName + "&age=" + String.valueOf(user.getAge()) + "&gender=" + String.valueOf(user.getGender()) + "&phone=" + user.getPhoneNumber() + "&authToken=null";
        HttpPost httpPost = new HttpPost(userUrl);

        try {
            // Execute HTTP Post Request
            HttpResponse response = httpclient.execute(httpPost);
        } catch (ClientProtocolException e) {
            // TODO Auto-generated catch block
        } catch (IOException e) {
            // TODO Auto-generated catch block
        }
        return true;
    }
}
