package com.example.trocket.roomme;

/**
 * Created by zp035497 on 7/13/15.
 */
public class User {

    private String fullName;
    private int age;
    private double matchScore;
    private String phoneNumber;
    private String email;
    private double HousingPrice;


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
}
