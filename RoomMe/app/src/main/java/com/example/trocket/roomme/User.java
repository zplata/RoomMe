package com.example.trocket.roomme;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * Created by zp035497 on 7/13/15.
 */
public class User implements Parcelable {

    private String fullName;
    private int age;
    private String phoneNumber;
    private String email;
    private double HousingPrice;


    /**
     * Sample user for now. Will make larger eventually.
     * @param name
     * @param age
     */
    public User(String name, int age) {
        fullName = name;
        this.age = age;
    }

    public String getName() { return fullName; }
    public int getAge() { return age; }
    public String getPhoneNumber() { return phoneNumber; }
    public String getEmail() { return email; }
    public void setPhoneNumber(String num) { phoneNumber = num;}
    public void setEmail(String email) { this.email = email; }

    // Placeholder
    public double getMatchScore() { return 6.9; }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(fullName);
        dest.writeInt(age);
    }

    private User(Parcel in) {
        String tempName = in.readString();
        int tempAge = in.readInt();
        this.fullName = tempName;
        this.age = tempAge;
    }

    public static final Parcelable.Creator<User> CREATOR = new Parcelable.Creator<User>() {

        @Override
        public User createFromParcel(Parcel source) {
            return new User(source);
        }

        @Override
        public User[] newArray(int size) {
            return new User[size];
        }
    };
}
