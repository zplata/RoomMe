package com.example.trocket.roomme;

import android.app.Fragment;
import android.graphics.Typeface;
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
    private TextView email;
    private TextView status;
    private TextView housingPrice;
    private TextView bio;
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

        Typeface face = Typeface.createFromAsset(getActivity().getAssets(), "fonts/ChaletNewYorkNineteenSixty.ttf");

        View rootView = inflater.inflate(R.layout.fragment_profile, container, false);
        pic = (com.beardedhen.androidbootstrap.BootstrapCircleThumbnail) rootView.findViewById(R.id.fp_user_picture);
        pic.setImage(R.drawable.isu);

        name = (TextView) rootView.findViewById(R.id.fp_name);
        bio = (TextView) rootView.findViewById(R.id.fp_bio);
        status = (TextView) rootView.findViewById(R.id.fp_status);
        housingPrice = (TextView) rootView.findViewById(R.id.fp_housingPrice);
        email = (TextView) rootView.findViewById(R.id.fp_email);
        addToList = (Button) rootView.findViewById(R.id.fp_addToList);
        fbMSG = (Button) rootView.findViewById(R.id.fp_fbMSG);

        TextView staticHousing = (TextView) rootView.findViewById(R.id.staticHousingInfo);
        TextView staticContact = (TextView) rootView.findViewById(R.id.staticContactInfo);

        staticHousing.setTypeface(face); staticContact.setTypeface(face);

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
        name.setText(position.getName() + ", " + position.getAge() + " (" + position.getGender() + ")");
        bio.setText(position.getBio() + "");
        status.setText(position.getStatus() + "");
        housingPrice.setText("$" + position.getHousingPrice() + "/month");
        email.setText(position.getEmail() + "");
        String name = position.getName();
        switch (name)
        {
            case "Abraham Lincoln" : pic.setImage(R.drawable.abe_lincoln);
                break;
            case "Barack Obama" : pic.setImage(R.drawable.barack_obama);
                break;
            case "Han Solo" : pic.setImage(R.drawable.han_solo_carbonite);
                break;
            case "Arnold Schwarzenegger" : pic.setImage(R.drawable.arnold_schwarzenegger);
                break;
            case "Beyonce Knowles" : pic.setImage(R.drawable.beyonce_knowles);
                break;
            case "The Batman" : pic.setImage(R.drawable.batman);
                break;
            case "Blackbeard" : pic.setImage(R.drawable.blackbeard);
                break;
            case "Mike Tyson" : pic.setImage(R.drawable.mike_tyson);
                break;
            case "Ariana Grande" : pic.setImage(R.drawable.ariana_grande);
                break;
            case "Ned Stark" : pic.setImage(R.drawable.ned_stark);
                break;
                default: pic.setImage(R.drawable.isu);
                    break;
        }
    }


}
