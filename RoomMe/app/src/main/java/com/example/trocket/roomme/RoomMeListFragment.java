package com.example.trocket.roomme;

import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import java.util.ArrayList;


public class RoomMeListFragment extends Fragment {

    private ArrayList<User> userList = new ArrayList<User>();
    private UserArrayAdapter adapter;

    private ListView list;

    public RoomMeListFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View rootView = inflater.inflate(R.layout.fragment_room_me_list, container, false);



        list = (ListView) rootView.findViewById(R.id.frml_users_list);
        adapter = new UserArrayAdapter(getActivity(), userList);
        list.setAdapter(adapter);

        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                getActivity().getFragmentManager().beginTransaction().replace(R.id.ah_content_frame,
                        new ProfileFragment()).commit();
            }
        });


        return rootView;
    }

}
