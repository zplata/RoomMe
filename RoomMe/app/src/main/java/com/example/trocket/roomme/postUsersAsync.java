package com.example.trocket.roomme;

import android.os.AsyncTask;

import java.util.ArrayList;

/**
 * Created by Billy on 7/19/15.
 */
public class postUsersAsync extends AsyncTask<User, Void, Boolean > {
        @Override
        protected Boolean doInBackground(User ...params)
        {
            try{
                //params[0] is the first argument given, in this case it is the User to be posted
                return JsonPoster.postJSON(params[0]);
            }
            catch(Exception e)
            {
                e.printStackTrace();
                return false;
            }
        }
        protected void onPostExecute(Boolean result)
        {

        }

}
