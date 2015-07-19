package com.example.trocket.roomme;

/**
 * Created by zp035497 on 7/15/15.
 */

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.example.trocket.roomme.HomeActivity.TestObject;

public class DrawerItemAdapter extends ArrayAdapter<TestObject> {
    Context mContext;
    int layoutResourceId;
    TestObject data[] = null;

    public DrawerItemAdapter(Context mContext, int layoutResourceId, TestObject[] data) {

        super(mContext, layoutResourceId, data);
        this.layoutResourceId = layoutResourceId;
        this.mContext = mContext;
        this.data = data;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        View listItem = convertView;

        LayoutInflater inflater = ((Activity) mContext).getLayoutInflater();
        listItem = inflater.inflate(layoutResourceId, parent, false);

        com.beardedhen.androidbootstrap.FontAwesomeText imageViewIcon = (com.beardedhen.androidbootstrap.FontAwesomeText)
                listItem.findViewById(R.id.dli_icon);
        TextView textViewName = (TextView) listItem.findViewById(R.id.dli_action);

        TestObject folder = data[position];

        if(position == 0) {
            imageViewIcon.setIcon("fa-home");
        }
        else if (position == 1) {
            imageViewIcon.setIcon("fa-user");
        }
        else if (position == 2) {
            imageViewIcon.setIcon("fa-edit");
        }
        else {
            imageViewIcon.setIcon("fa-list-alt");
        }
        textViewName.setText(folder.action);

        return listItem;
    }
}
