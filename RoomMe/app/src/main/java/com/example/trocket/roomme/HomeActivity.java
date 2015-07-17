package com.example.trocket.roomme;

import android.content.Intent;
import android.os.AsyncTask;
import android.content.res.Configuration;
import android.os.Bundle;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBarDrawerToggle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;


public class HomeActivity extends ActionBarActivity implements AsyncJSONResponse{

    private ArrayList<User> userList = new ArrayList<User>();
    private UserArrayAdapter adapter;
    JsonAccessor jsonGetter = new JsonAccessor();

    private ListView list;

    // Nav Drawer Views
    private DrawerLayout nav_drawer_layout;
    private ListView nav_list;
    private ActionBarDrawerToggle nav_drawer_toggle;
    private ArrayAdapter<String> nav_adapter;

    private String nav_title;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
        jsonGetter.delegate = this;

        //int test = yayJson.derp();
        // Dummy data
        for(int i = 0; i < 10; i++) {
            userList.add(i, new User());
        }

        list = (ListView) findViewById(R.id.ah_users_list);
        adapter = new UserArrayAdapter(this, userList);
        list.setAdapter(adapter);

        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent i = new Intent(getApplicationContext(), ProfileViewActivity.class);
                startActivity(i);
                setContentView(R.layout.activity_profile_view);
            }
        });


        //Execute the JsonAccessor with an Api address
        //This is an example
        //jsonGetter.execute("http://date.jsontest.com/");


        nav_drawer_layout = (DrawerLayout) findViewById(R.id.ah_drawer_layout);
        nav_list = (ListView) findViewById(R.id.ah_nav_list);
        nav_title = getTitle().toString();

        addDrawerItems();
        setupDrawer();

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setHomeButtonEnabled(true);

    }

    private void addDrawerItems() {
        String[] osArray = {"My Profile", "Edit Profile", "RoomMe List"};
        nav_adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, osArray);
        nav_list.setAdapter(nav_adapter);

        nav_list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Toast.makeText(HomeActivity.this, "Time for an upgrade!", Toast.LENGTH_SHORT).show();
            }
        });
    }

    private void setupDrawer() {
        nav_drawer_toggle = new ActionBarDrawerToggle(this, nav_drawer_layout, R.string.drawer_open, R.string.drawer_close) {

            /** Called when a drawer has settled in a completely open state. */
            public void onDrawerOpened(View drawerView) {
                super.onDrawerOpened(drawerView);
                getSupportActionBar().setTitle("Take Action!");
                invalidateOptionsMenu(); // creates call to onPrepareOptionsMenu()
            }

            /** Called when a drawer has settled in a completely closed state. */
            public void onDrawerClosed(View view) {
                super.onDrawerClosed(view);
                getSupportActionBar().setTitle(nav_title);
                invalidateOptionsMenu(); // creates call to onPrepareOptionsMenu()
            }
        };

        nav_drawer_toggle.setDrawerIndicatorEnabled(true);
        nav_drawer_layout.setDrawerListener(nav_drawer_toggle);
        nav_drawer_layout.setDrawerShadow(R.drawable.drawer_shadow, GravityCompat.START);
    }


    @Override
    protected void onPostCreate(Bundle savedInstanceState) {
        super.onPostCreate(savedInstanceState);
        nav_drawer_toggle.syncState();
    }

    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);
        nav_drawer_toggle.onConfigurationChanged(newConfig);
    }

    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_home, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onPrepareOptionsMenu(Menu menu) {
        boolean drawerOpen = nav_drawer_layout.isDrawerOpen(nav_list);
        menu.findItem(R.id.action_settings).setVisible(!drawerOpen);
        return super.onPrepareOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.

        if(nav_drawer_toggle.onOptionsItemSelected(item)) {
            return true;
        }
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    //onJsonProcessFinish is automatically called when the JsonAccessor finishes
    //object should be a string that contains the JSON data from the given URL
    public String onJsonProcessFinish(String object)
    {
        System.out.println(object);
        return object;
    }
}


