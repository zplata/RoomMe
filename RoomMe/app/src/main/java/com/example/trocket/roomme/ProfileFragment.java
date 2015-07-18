package com.example.trocket.roomme;

import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import java.util.ArrayList;


public class ProfileFragment extends Fragment {

    private com.beardedhen.androidbootstrap.BootstrapCircleThumbnail pic;
    private TextView name;
    private TextView age;
    private Button addToList;
    private Button fbMSG;
    private ArrayList<User> user;

    //private JsonAccessor jsonGetter;

    final static String ARG_POSITION = "position";

    public ProfileFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_profile, container, false);
        pic = (com.beardedhen.androidbootstrap.BootstrapCircleThumbnail) rootView.findViewById(R.id.fp_user_picture);
        pic.setImage(R.drawable.isu);

        name = (TextView) rootView.findViewById(R.id.fp_name);
        age = (TextView) rootView.findViewById(R.id.fp_age);
        addToList = (Button) rootView.findViewById(R.id.fp_addToList);
        fbMSG = (Button) rootView.findViewById(R.id.fp_fbMSG);

        Bundle args = getArguments();
        if(args != null) {
            updateProfileView((User) args.getParcelable(ProfileFragment.ARG_POSITION));
        }

        return rootView;
    }

   /* @Override
    public void onStart() {
        super.onStart();

        Bundle args = getArguments();
        if (args != null) {
            updateProfileView((User) args.getParcelable(ProfileFragment.ARG_POSITION));
        }
    }*/

    public void updateProfileView(User position) {
        name.setText(position.getName());
        age.setText(position.getAge() + "");
    }


}
