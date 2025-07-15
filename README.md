📝 Sign-Up Form
The Sign-Up Form allows new users to register by creating a unique username and password. It communicates directly with Firebase to store credentials securely.

Key Features:
🆕 User Registration: Collects and saves username/password pairs to the Realtime Database.

✅ Validation Checks: Ensures all fields are filled out before submission.

🔐 Secure Password Handling: Passwords are masked during input.

Sample Workflow:
User clicks “Sign Up” from the login screen.

Form opens in a new window for credential entry.

On successful registration, the user is notified and can return to log in.

Firebase Integration:
Data is sanitized to prevent Firebase key formatting issues (e.g., replaces characters like ., #, $).

Each user is stored under /Users/{username} in the database.

🔐 Sign-Up Functionality
The SignUpForm component allows users to securely create a new account by registering their credentials to Firebase.

✨ Features
🔧 Realtime Database connectivity via FireSharp

✍️ Simple username and password input

🔍 Duplicate username check

✅ Clean feedback through Windows message boxes

🔑 Toggle password visibility for better UX

🔄 How It Works
The form initializes with Firebase configuration.

On "Register" click:

Validates input fields

Checks if the user already exists in Firebase

If not found, stores the new user securely

Firebase keys are sanitized to comply with database constraints.

⚠️ Notes
Passwords are stored in plain text for demo purposes—not recommended for production apps. Use hashing libraries (e.g. bcrypt, PBKDF2) for secure storage in live applications.

🔄 User Flow Overview
🆕 Sign Up: New users must first create an account using a unique username and password.

🔓 Login: After successful registration, users return to the main form to log in with their new credentials.

✅ Access Granted: If authentication succeeds, the app confirms the login and proceeds with user-specific operations.

💡 Tip: For demo/testing purposes, try creating multiple users and logging in/out to observe how Firebase handles your data.

🔄 App Workflow
📝 Sign Up

New users register using their unique username and password.

Data is securely stored in Firebase Realtime Database.

🔐 Login

Registered users can authenticate to access the chat interface.

Login validation checks credentials in real time.

💬 Access chatForm

After successful login, users enter the chat environment.

They can:

View online status

Add friends and manage contacts

Send private and group messages

Create new chat groups with selected friends

Receive real-time message updates via Firebase subscriptions

Log out and safely clear UI data

⚙️ Firebase handles all backend storage and data synchronization with minimal configuration required on the client.
