package com.example.trocket.roomme;

import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import java.util.ArrayList;


public class HomeFragment extends Fragment implements AsyncJSONResponse {

    private ArrayList<User> userList = new ArrayList<User>();
    private UserArrayAdapter adapter;

    private ListView list;
    private JsonAccessor jsonGetter;


    public HomeFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        jsonGetter = new JsonAccessor();
        jsonGetter.delegate = this;
        jsonGetter.execute("http://roomme.azurewebsites.net/Api/user");
        View rootView = inflater.inflate(R.layout.fragment_home, container, false);

        for(int i = 0; i < 10; i++) {
            userList.add(i, new User("Replace This w/ a Users name", 21));
        }

        list = (ListView) rootView.findViewById(R.id.fh_users_list);
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

    @Override
    public String onJsonProcessFinish(String output) {
        return null;
    }
}
