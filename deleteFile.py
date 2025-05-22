import os
import time
import glob

# Path to your folder
folder_path = "C:/Users/gwapo/OneDrive/Desktop/Delete"  # Update with the actual path

# File extensions to delete
extensions = ['*.pdf', '*.docx', '*.xlsx', '*.doc']

# Function to delete files older than 15 minutes
def delete_files():
    current_time = time.time()  # Get the current time in seconds
    for ext in extensions:
        files = glob.glob(os.path.join(folder_path, ext))
        for file in files:
            try:
                # Get the creation time of the file (on Windows it might be 'ctime', on Unix it might be 'stat')
                creation_time = os.path.getctime(file)
                
                # Check if the file is older than 5 minutes (300 seconds)
                if current_time - creation_time > 300:
                    os.remove(file)
                    print(f"Deleted: {file}")
            except Exception as e:
                print(f"Error deleting {file}: {e}")

# Main function to run the deletion every 5 minutes
def main():
    countdown_time = 300  # 5 minutes in seconds
    
    while True:
        try:
            # Countdown timer (updated every second)
            for remaining in range(countdown_time, 0, -1):  # Countdown by 1 second
                minutes_left = remaining // 60
                seconds_left = remaining % 60
                print(f"Time left for next deletion: {minutes_left} minutes {seconds_left} seconds", end='\r')
                time.sleep(1)  # Wait for 1 second
            
            delete_files()
            
        except KeyboardInterrupt:
            print("\nProcess interrupted by user.")
            break
        except Exception as e:
            print(f"\nAn error occurred: {e}")
            time.sleep(900)  # Sleep before retrying to avoid high CPU usage

if __name__ == "__main__":
    main()

#testing