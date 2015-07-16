package com.example.trocket.roomme;

import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;


public class ProfileFragment extends Fragment {

    private com.beardedhen.androidbootstrap.BootstrapCircleThumbnail pic;
    private TextView name;
    private TextView tempMsg;
    private Button addToList;
    private Button fbMSG;

    public ProfileFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View rootView = inflater.inflate(R.layout.fragment_profile, container, false);
        pic = (com.beardedhen.androidbootstrap.BootstrapCircleThumbnail) rootView.findViewById(R.id.fp_user_picture);
        pic.setImage(R.drawable.isu);

        name = (TextView) rootView.findViewById(R.id.fp_name);
        tempMsg = (TextView) rootView.findViewById(R.id.fp_msg);
        name.setText("Zach Test");
        addToList = (Button) rootView.findViewById(R.id.fp_addToList);
        fbMSG = (Button) rootView.findViewById(R.id.fp_fbMSG);



        return rootView;
    }

}
