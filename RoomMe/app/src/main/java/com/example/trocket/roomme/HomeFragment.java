package com.example.trocket.roomme;

import android.app.Activity;
import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import java.util.ArrayList;


public class HomeFragment extends Fragment {

    private ArrayList<User> userList = new ArrayList<User>();
    private UserArrayAdapter adapter;

    private ListView list;
    //private JsonAccessor jsonGetter;

    OnUserSelectedListener listen;

    public interface OnUserSelectedListener {
        public void onUserSelected(User position);
    }


    public HomeFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_home, container, false);
        Activity act = getActivity();
        listen = (OnUserSelectedListener) act;

        userList.add(new User("Timmy", 1));
        userList.add(new User("Toomy", 2));
        userList.add(new User("Zach", 3));

        list = (ListView) rootView.findViewById(R.id.fh_users_list);
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


}
