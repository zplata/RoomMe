package com.example.trocket.roomme;

import android.app.Fragment;
import android.app.FragmentManager;
import android.content.Intent;
import android.content.res.Configuration;
import android.os.Bundle;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;


public class HomeActivity extends AppCompatActivity {

    private ArrayList<User> userList = new ArrayList<User>();
    private UserArrayAdapter adapter;

    private ListView list;

    // Nav Drawer Views
    private DrawerLayout nav_drawer_layout;
    private ListView nav_list;
    private ActionBarDrawerToggle nav_drawer_toggle;
    private DrawerItemAdapter nav_adapter;

    private CharSequence nav_title;
    private String[] nav_actions;
    private TestObject[] testObjs;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        // Dummy data
        for(int i = 0; i < 10; i++) {
            userList.add(i, new User());
        }
        testObjs = new TestObject[3];
        testObjs[0] = new TestObject(R.drawable.ic_launcher, "My Profile");
        testObjs[1] = new TestObject(R.drawable.ic_launcher, "Edit Profile");
        testObjs[2] = new TestObject(R.drawable.ic_launcher, "RoomMe List");

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

        nav_drawer_layout = (DrawerLayout) findViewById(R.id.ah_drawer_layout);
        nav_list = (ListView) findViewById(R.id.ah_nav_list);
        nav_title = getTitle();
        nav_actions = getResources().getStringArray(R.array.actions_array);

        addDrawerItems();

        nav_list.setOnItemClickListener(new DrawerItemClickListener());

        setupDrawer();

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setHomeButtonEnabled(true);

    }

    private class DrawerItemClickListener implements ListView.OnItemClickListener{

        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
            selectItem(position);
        }
    }

    private void addDrawerItems() {
        nav_adapter = new DrawerItemAdapter(this, R.layout.drawer_list_item, testObjs);
        nav_list.setAdapter(nav_adapter);
    }

    private void selectItem(int position) {
        Fragment fragment = null;

        switch (position) {
            case 0:
                fragment = new MyProfileFragment();
                break;
            case 1:
                fragment = new ProfileEditFragment();
                break;
            case 2:
                fragment = new RoomMeListFragment();
                break;
            default:
                break;
        }
        if (fragment != null) {
            FragmentManager fragMan = getFragmentManager();
            fragMan.beginTransaction().replace(R.id.ah_content_frame, new MyProfileFragment()).commit();
            Toast.makeText(getApplicationContext(), "THIS MOOOOOOOO", Toast.LENGTH_LONG).show();

            nav_list.setItemChecked(position, true);
            nav_list.setSelection(position);
            setTitle(nav_actions[position]);
            nav_drawer_layout.closeDrawer(nav_list);
        }
        else{
            Toast.makeText(getApplicationContext(), "THIS DIDNT WORK", Toast.LENGTH_LONG).show();
        }
    }

    @Override
    public void setTitle(CharSequence title) {
        nav_title = title;
        getSupportActionBar().setTitle(nav_title);
    }

    public class TestObject {
        public int icon;
        public String action;

        public TestObject(int icon, String action) {
            this.icon = icon;
            this.action = action;
        }
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
}
