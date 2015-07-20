package com.example.trocket.roomme;

import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Spinner;


public class ProfileEditFragment extends Fragment {

    private Spinner status;
    private int statusPosition;

    String[] items = {
            "Has vacancy",
            "Needs housing and roommate",
            "Only need roommate(s)",
            "Inactive"
    };

    public ProfileEditFragment() {

    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View rootView = inflater.inflate(R.layout.fragment_profile_edit, container, false);
        status = (Spinner) rootView.findViewById(R.id.fpe_edit_status);


        /*ArrayAdapter<CharSequence> staticAdapter = ArrayAdapter.createFromResource(getActivity().getApplicationContext(),
                R.array.status_options, android.R.layout.simple_spinner_item);
        status.setAdapter(staticAdapter);*/
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity().getApplicationContext(),
                R.layout.spinner_item, items);
        adapter.setDropDownViewResource(R.layout.spinner_item);
        status.setAdapter(adapter);
        status.setSelection(0);
        status.setOnItemSelectedListener(new SpinnerItemSelected());

        return rootView;
    }

    private class SpinnerItemSelected implements AdapterView.OnItemSelectedListener {

        @Override
        public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
            statusPosition = position;
        }

        @Override
        public void onNothingSelected(AdapterView<?> parent) {

        }
    }


}
