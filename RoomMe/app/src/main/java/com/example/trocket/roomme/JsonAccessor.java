package com.example.trocket.roomme;

import org.apache.http.HttpConnection;
import org.apache.http.protocol.HTTP;

import java.io.IOException;
import java.net.URL;
import java.net.MalformedURLException;
import java.net.HttpURLConnection;

/**
 * Created by Billy on 7/15/15.
 */
 public class JsonAccessor {

    public static HttpURLConnection getValues()
    {
        try
        {
            URL serviceURL = new URL("http://roomme.azurewebsites.net/api/Values");
            HttpURLConnection httpCon = (HttpURLConnection) serviceURL.openConnection();

            httpCon.setRequestMethod("GET");
            httpCon.setRequestProperty("Accept", "application/json");
        }
        catch ( MalformedURLException e)
        {
            e.printStackTrace();
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }

    }
}
