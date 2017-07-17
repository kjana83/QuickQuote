using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;

namespace QuickQuote.Model
{
    public enum DrivingStyle
    {
        LeftHanded,
        RightHanded
    }

    public enum NightParking
    {
        OnTheRoad,
        OnAPrivateDriveway,
        InALockedGarage,
        InAnUnlockedGarage
    }

    public enum DayParking
    {
        AtHome,
        WorkPlaceCarParking,
        OpenPublicCarParking
    }

    public enum VehicleFittedDevices
    {
        Alarm,
        Immobiliser,
        TrackingDevice        
    }

    [Serializable]
    public class QuickQuote
    {
        [Prompt("Please enter your {&}?")]
        public string FullName { get; set; }
        [Prompt("Please enter your home {&}")]
        public string Address { get; set; }
        [Prompt("Please enter your vehicle Registeration number")]
        public string RegisterationNumber { get; set; }
        [Prompt("What is your {&}? {||}")]
        public DrivingStyle? DrivingStyle { get; set; }
        [Prompt("Where do you park during night time? {||}")]
        public NightParking? NightParking { get; set; }
        [Prompt("Where do you part during day time? {||}")]
        public DayParking DayParking { get; set; }
        [Prompt("When did you purchase your vehicle?")]
        public DateTime VehiclePurchase { get; set; }
        [Prompt("What is the estimated value of your Car? £")]
        public Double EstimatedValue { get; set; }
        [Prompt("What are the safety devices fitted in your vehicle? {||}")]
        public List<VehicleFittedDevices> VehicleFittedWith { get; set; }
        [Prompt("Have you been modified your vehicle? {||}")]
        public bool? VechileModified { get; set; }
        [Prompt("How many seats your vehicle have?")]
        public int? NumberOfSeats { get; set; }

        public static IForm<QuickQuote> BuildForm()
        {
            return new FormBuilder<QuickQuote>()
                .Message("Welcome to QuickQuote Bot")
                .Build();
        }
    }
}