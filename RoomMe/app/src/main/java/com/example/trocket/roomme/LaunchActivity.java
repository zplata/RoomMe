package com.example.trocket.roomme;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

import com.facebook.AccessToken;
import com.facebook.FacebookSdk;

/**
 * Created by rsgallus on 7/19/15.
 */
public class LaunchActivity extends Activity {

    private static int TIME_OUT = 3000;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        FacebookSdk.sdkInitialize(getApplicationContext());
        setContentView(R.layout.activity_launch);

        new Handler().postDelayed(new Runnable() {

            @Override
            public void run() {
                Intent intent;
                if (isLoggedIn()) {
                    intent = new Intent(LaunchActivity.this, HomeActivity.class);
                }
                else {
                    intent = new Intent(LaunchActivity.this, LoginActivity.class);
                }

                startActivity(intent);
                finish();
            }
        }, TIME_OUT);

    }

    public boolean isLoggedIn() {
        AccessToken accessToken = AccessToken.getCurrentAccessToken();
        return accessToken != null;
    }
}
