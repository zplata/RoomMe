package com.example.trocket.roomme;

import android.os.AsyncTask;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.StatusLine;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
/**
 * Created by Billy on 7/15/15.
 */
public class JsonAccessor extends AsyncTask<String, Void, String>{

    public AsyncJSONResponse delegate = null;

    //getJSON is called from the asyncronous method doInBackground
    //This method takes a url, and tries to retrieve a JSON string from that location
    public static String getJSON(String url)
    {
        StringBuilder builder = new StringBuilder();
        HttpClient client = new DefaultHttpClient();
        HttpGet siteHttp = new HttpGet(url);
        try
        {
            HttpResponse response = client.execute(siteHttp);
            StatusLine statusLine = response.getStatusLine();
            int statusCode = statusLine.getStatusCode();
            if (statusCode == 200)
            {
                HttpEntity entity = response.getEntity();
                InputStream content = entity.getContent();
                BufferedReader reader = new BufferedReader(new InputStreamReader(content));
                String line;
                while ((line = reader.readLine() )!= null)
                {
                    builder.append(line);
                }
            } else
            {
                System.out.println("Failed to Access Json!");
                return null;
            }
        } catch (ClientProtocolException e )
        {
            e.printStackTrace();
        } catch ( IOException e)
        {
            e.printStackTrace();
        }

        return builder.toString();

    }

    //doInBackground is the method called when a JsonAccessor.execute("url") is called
    @Override
    protected String doInBackground(String...urls)
    {
        try{
            //urls[0] is the first argument given, in this case it is the URL to be accessed
            String derp = getJSON(urls[0]);
            //System.out.println(derp);
            return derp;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    protected void onPostExecute(String result)
    {
        delegate.onJsonProcessFinish(result);
    }

}
