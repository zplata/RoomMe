package com.example.trocket.roomme;

/**
 * Created by Billy on 7/16/15.
 * AsyncJSONResponse is an interface used to handle a returned JSON string from the JsonAccessor
 */
public interface AsyncJSONResponse {
    void onJsonProcessFinish(String output);
}
