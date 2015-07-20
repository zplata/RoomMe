package com.example.trocket.roomme;

import android.app.Fragment;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
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

import com.facebook.FacebookSdk;

import java.util.ArrayList;





public class HomeActivity extends AppCompatActivity implements HomeFragment.OnUserSelectedListener {

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

    private FragmentManager fragMan;
    private FragmentTransaction tx;
    getUsersAsync getUsers;
    getCareersAsync getCareers;
    getLocationsAsync getLocations;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        FacebookSdk.sdkInitialize(getApplicationContext());
        setContentView(R.layout.activity_home);
        getFragmentManager().beginTransaction().replace(R.id.ah_content_frame, new HomeFragment()).commit();


        testObjs = new TestObject[4];
        testObjs[0] = new TestObject(R.drawable.action_search, "Home");
        testObjs[1] = new TestObject(R.drawable.action_search, "My Profile");
        testObjs[2] = new TestObject(R.drawable.action_search, "Edit Profile");
        testObjs[3] = new TestObject(R.drawable.action_search, "RoomMe List");


        //Execute a JsonGetter. It will call a response method when it finishes
        //This is an example
        getUsers = new getUsersAsync(this);
        getUsers.execute(1);


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

    @Override
    public void onUserSelected(User position) {
        ProfileFragment pro_frag = new ProfileFragment();
        Bundle args = new Bundle();
        args.putParcelable(ProfileFragment.ARG_POSITION, position);
        pro_frag.setArguments(args);

        getFragmentManager().beginTransaction().replace(R.id.ah_content_frame, pro_frag).commit();
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
                fragment = new HomeFragment();

                break;
            case 1:
                fragment = new ProfileFragment();
                Bundle args = new Bundle();
                args.putParcelable(ProfileFragment.ARG_POSITION, HoldMyUserObject.my_user_object);
                fragment.setArguments(args);
                break;
            case 2:
                fragment = new ProfileEditFragment();
                break;
            case 3:
                fragment = new RoomMeListFragment();
                break;
            default:
                break;
        }

        if (fragment != null) {
            fragMan = getFragmentManager();
            tx = fragMan.beginTransaction();
            tx.replace(R.id.ah_content_frame, fragment).addToBackStack("tag").commit();

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


    //Response methods are automatically called when the getAsync method finishes
    //object passed in should be an arraylist of appropriate type
    void getUsersResponse( ArrayList<User> result)
    {
        if (result !=null) {
            System.out.println(result.get(0).getName());
            userList = result;
            selectItem(0);
        }
    }
    void getLocationsResponse( ArrayList result)
    {
    }
    void getCareersResponse( ArrayList result)
    {
    }
}


