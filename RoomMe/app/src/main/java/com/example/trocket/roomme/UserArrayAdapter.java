package com.example.trocket.roomme;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;

/**
 * Created by zp035497 on 7/13/15.
 */
public class UserArrayAdapter extends ArrayAdapter<User> {
    private final Context context;
    private final ArrayList<User> values;

    public UserArrayAdapter(Context context, ArrayList<User> values) {
        super(context, R.layout.user_list_view, values);
        this.context = context;
        this.values = values;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if(convertView == null) {
            convertView = LayoutInflater
                    .from(getContext()).inflate(R.layout.user_list_view, parent, false);
        }

        User user = values.get(position);

        TextView match_score_view = (TextView) convertView.findViewById(R.id.ulv_match_score);
        TextView user_name_view = (TextView) convertView.findViewById(R.id.ulv_user_name);
        ImageView user_pic_view = (ImageView) convertView.findViewById(R.id.ulv_user_pic);

        user_name_view.setText(user.getFirstName());
        match_score_view.setText(user.getMatchScore() + "");

        return convertView;
    }
}
