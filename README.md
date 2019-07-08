# Xamarin.Playground
playground for my xamarin applications


In this area I publish some of my usefull controls, codesnippets or other helper stuff.
I also publish some of my test projects in this area

# ToDo
- [x] FAB
- [x] FAB.iOS
- [x] RadioButton
- [ ] RadioButton.iOS
- [ ] QuizlyBears
- [ ] OrderReminder
- [ ] Map with custom icons


# Floating Action Button (FAB)
custom floating action button for Xamarin.Android and Xamarin.UWP. (IOS will coming soon).
This control is using platform specific view render and a xamarin.forms control. 
So it is very easy to use:

```xaml
<floatingActionButton:FloatingActionButton ButtonColor="Blue"
                                                   HeightRequest="50"
                                                   Margin="20"
                                                   HorizontalOptions="End"
                                                   WidthRequest="50">
            <floatingActionButton:FloatingActionButton.ImageSource>
                <OnPlatform x:TypeArguments="ImageSource" >
                    <On Platform="UWP" Value="Assets/search.png"/>
                    <On Platform="Android" Value="search.png"/>
                </OnPlatform>
            </floatingActionButton:FloatingActionButton.ImageSource>
        </floatingActionButton:FloatingActionButton>
```

![Alt text](/Screenshots/FAB/androidfab.png?raw=true "Android FAB")![Alt text](/Screenshots/FAB/uwpfab.png?raw=true "UWP FAB")

# Radio Button
custom radio button for Xamarin.Android and Xamarin.UWP (iOS will coming soon).
This control is using platform specific view renderer and a xamarin.forms control.
For using you have to do the following:

```xaml
        <radioButton:RadioButtonGroup x:Name="RadioButtonGroup"/>
```

For the RadioButtons you have to fill the ItemSource in the code behind or via Binding.

``` c#
RadioButtonGroup.ItemsSource = new[]
            {
               "Austria",
               "Germany", 
               "France", 
               "Italy"
            };
```
![Alt text](/Screenshots/RadioButton/android.png?raw=true "Android")![Alt text](/Screenshots/RadioButton/UWP.PNG?raw=true "UWP")


# PlatformImageExtension
If you want to use an image in Xamarin.Forms you have to use a differnt path or name for each plaftorm. 

This may make the xaml file difficult to read, because you have to add platform specfic code in XAML like this

```xaml
         <local:FloatingActionButton ButtonColor="Blue"
                                                   HeightRequest="50"
                                                   Margin="20"
                                                   HorizontalOptions="End"
                                                   WidthRequest="50">
            <local:FloatingActionButton.ImageSource>
                <OnPlatform x:TypeArguments="ImageSource" >
                    <On Platform="UWP" Value="Assets/search.png"/>
                    <On Platform="Android" Value="search.png"/>
                </OnPlatform>
            </local:FloatingActionButton.ImageSource>
        </local:FloatingActionButton>
```

Instead of those lines of code, you can also use a marukup extension which merge the image for you: 

```xaml
        <local:FloatingActionButton ButtonColor="Blue"
                                                   HeightRequest="50"
                                                   Margin="20"
                                                   HorizontalOptions="End"
                                                   WidthRequest="50"
                                                   ImageSource="{local:PlatformImageExtensions SourceImage='Icon'}">
        </local:FloatingActionButton>
```


