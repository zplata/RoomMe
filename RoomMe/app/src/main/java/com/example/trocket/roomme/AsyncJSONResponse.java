package com.example.trocket.roomme;

import java.util.ArrayList;

/**
 * Created by Billy on 7/16/15.
 * AsyncJSONResponse is an interface used to handle a returned JSON string from the JsonAccessor
 */
public interface AsyncJSONResponse {
    ArrayList<User> onJsonProcessFinish(ArrayList<User> output);
}
