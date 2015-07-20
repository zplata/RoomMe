package com.example.trocket.roomme;

/**
 * Created by zp035497 on 7/20/15.
 */
public class HoldMyUserObject {

    public static User my_user_object;

    public HoldMyUserObject(User obj) {
        my_user_object = obj;
    }

    public User getObj() {
        return my_user_object;
    }

}
