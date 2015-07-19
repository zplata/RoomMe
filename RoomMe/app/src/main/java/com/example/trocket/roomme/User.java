package com.example.trocket.roomme;

import android.os.Parcel;
import android.os.Parcelable;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by zp035497 on 7/13/15.
 */
public class User implements Parcelable {

    private int userID;
    private String fullName;
    private int gender;
    private int age;
    private String phoneNumber;
    private String email;
    private int status;
    private double housingPrice;
    private String bio;
    private List<Integer> favoritesUserIDS;

    /**
     * Sample user for now. Will make larger eventually.
     * @param name
     * @param age
     */
    public User(int userID, String name, int gender, int age, String phoneNumber,
                String email, int status, double housingPrice, String bio, List<Integer> favoritesUserIDS) {
        this.userID = userID;
        fullName = name;
        this.gender = gender;
        this.age = age;
        this.phoneNumber = phoneNumber;
        this.email = email;
        this.status = status;
        this.housingPrice = housingPrice;
        this.bio = bio;
        this.favoritesUserIDS = favoritesUserIDS;
    }

    public int getUserID() { return userID; }
    public String getName() { return fullName; }
    public int getGender() { return gender; }
    public int getAge() { return age; }
    public String getPhoneNumber() { return phoneNumber; }
    public String getEmail() { return email; }
    public int getStatus() { return status; }
    public double getHousingPrice() { return housingPrice; }
    public String getBio() { return bio; }
    public List<Integer> getFavoritesUserIDS() { return favoritesUserIDS; }
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
        dest.writeInt(userID);
        dest.writeString(fullName);
        dest.writeInt(gender);
        dest.writeInt(age);
        dest.writeString(phoneNumber);
        dest.writeString(email);
        dest.writeInt(status);
        dest.writeDouble(housingPrice);
        dest.writeString(bio);
        dest.writeList(favoritesUserIDS);
    }

    private User(Parcel in) {
        this.userID = in.readInt();
        this.fullName = in.readString();
        this.gender = in.readInt();
        this.age = in.readInt();
        this.phoneNumber = in.readString();
        this.email = in.readString();
        this.status = in.readInt();
        this.housingPrice = in.readDouble();
        this.bio = in.readString();
        this.favoritesUserIDS = new ArrayList<Integer>();
        in.readList(favoritesUserIDS, null);
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
