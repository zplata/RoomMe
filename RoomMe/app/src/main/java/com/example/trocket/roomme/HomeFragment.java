package com.example.trocket.roomme;

import android.app.Activity;
import android.app.Fragment;
import android.graphics.Typeface;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;


public class HomeFragment extends Fragment {

    public ArrayList<User> userList = new ArrayList<User>();
    private UserArrayAdapter adapter;
    getUsersAsync getUsers;
    postUsersAsync postUser;

    private ListView list;
    private TextView banner;
    //private JsonAccessor jsonGetter;

    OnUserSelectedListener listen;

    public interface OnUserSelectedListener {
        public void onUserSelected(User position);
    }


    public HomeFragment( ) {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        Typeface face = Typeface.createFromAsset(getActivity().getAssets(), "fonts/ChaletNewYorkNineteenSixty.ttf");
        View rootView = inflater.inflate(R.layout.fragment_home, container, false);
        Activity act = getActivity();
        listen = (OnUserSelectedListener) act;
        //Execute a JsonGetter. It will call a response method when it finishes
        //This is an example
        getUsers = new getUsersAsync(this);
        getUsers.execute(2);


        list = (ListView) rootView.findViewById(R.id.fh_users_list);
        banner = (TextView) rootView.findViewById(R.id.staticBanner);
        banner.setTypeface(face);
        adapter = new UserArrayAdapter(getActivity(), userList);
        list.setAdapter(adapter);

        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                listen.onUserSelected(userList.get(position));
                /*getActivity().getFragmentManager().beginTransaction().replace(R.id.ah_content_frame,
                new ProfileFragment()).commit();*/
            }
        });


        return rootView;
    }

    void getUsersResponse( ArrayList<User> result)
    {
        if (result !=null) {
            this.userList = result;
            adapter.addAll(result);
            adapter.notifyDataSetChanged();
        }
    }
}
