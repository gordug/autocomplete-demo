# Autocomplete: README.md

## Table of Contents
- [Introduction](#introduction)
- [Installation](#installation)
- [Usage](#usage)
  - [Expected Behavior](#expected-behavior)
  - [Actual Behavior](#actual-behavior)
- [License](#license)

## Introduction
This is a demo project to highlight the issue with modern browsers ignoring the `autocomplete="off"` attribute.

## Installation
1. Clone the repository
2. Run the following commands
   1. `dotnet restore`
   2. `cd AutoCompleteDemo`
   3. `dotnet ef database update --context DeviceUserDbContext`
   4. `dotnet ef database update --context ApplicationDbContext`
   5. `dotnet run`

## Usage
1. Open the browser and navigate to site
2. Click on the `Register` link
3. Fill in the form and submit
4. Activate your user account by clicking the link
5. Log in with the credentials you used to register
6. Navigate to Device Users and add a new device user

### Expected Behavior
The browser should not suggest any previously entered values in the form fields.

### Actual Behavior
The browser suggests previously entered values in the form fields.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
