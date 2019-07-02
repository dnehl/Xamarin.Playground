# Xamarin.Playground
playground for my xamarin applications


In this area I publish some of my usefull controls, codesnippets or other helper stuff.
I also publish some of my test projects in this area


# Floating Action Button (FAB)
custom floating action button for Xamarin.Android and Xamarin.UWP. (IOS will coming soon).
This control is using platform specific view render and a xamarin.forms control. 
So it is very easy to use:

```c#
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
