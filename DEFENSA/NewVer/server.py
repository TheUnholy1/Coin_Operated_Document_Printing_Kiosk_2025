from flask import Flask, request, render_template_string, make_response
import os
import socket

app = Flask(__name__)
upload_folder = 'C:/DEFENSA'

if not os.path.exists(upload_folder):
    os.makedirs(upload_folder)

app.config['UPLOAD_FOLDER'] = upload_folder
app.config['MAX_CONTENT_LENGTH'] = 1 * 1024 * 1024 * 1024  # 1 GB file size limit

ip_address_file = 'C:/DEFENSA/ip_address.txt'  # Specify the path here

# HTML templates
upload_template = """
<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>Coin Operated Document Printing Kiosk</title>
  <style>
    body {
      font-family: Arial, sans-serif;
      background: linear-gradient(to bottom, #050933, #00b9c7);
      color: white;
      height: 100vh;
      display: flex;
      justify-content: center;
      align-items: center;
      margin: 0;
    }
    .container {
      background: rgba(255, 255, 255, 0.1);
      padding: 30px;
      border-radius: 10px;
      text-align: center;
      box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.3);
      max-width: 400px;
    }
    .form-group {
      margin-bottom: 20px;
    }
    input[type=file] {
      padding: 10px;
      width: 100%;

      border: none;
      border-radius: 5px;
    }
    button[type=submit] {
      background-color: #00b9c7;
      color: white;
      padding: 10px 20px;
      border: none;
      cursor: pointer;
      border-radius: 5px;
      width: 100%;
      font-size: 16px;
    }
    h1, h2 {
      color: white;
    }
    .error-message {
      color: red;
      font-weight: bold;
      margin-bottom: 20px;
    }
  </style>
</head>
<body>
  <div class="container">
    <h1>Coin Operated Document Printing Kiosk</h1>
    <h2>Upload a File</h2>
    {% if error_message %}
      <p class="error-message">{{ error_message }}</p>
    {% endif %}
    <form method="post" enctype="multipart/form-data" action="/">
      <div class="form-group">
        <input type="file" name="file" accept=".pdf,.xls,.xlsx,.doc,.docx">
      </div>
      <div class="form-group">
        <button type="submit">Upload</button>
      </div>
    </form>
  </div>
</body>
</html>
"""

uploaded_template = """
<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>File Uploaded</title>
  <style>
    body {
      font-family: Arial, sans-serif;
      background: linear-gradient(to bottom, #050933, #00b9c7);
      color: white;
      height: 100vh;
      display: flex;
      justify-content: center;
      align-items: center;
      margin: 0;
    }
    .container {
       background: rgba(255, 255, 255, 0.1);
      padding: 30px;
      border-radius: 10px;
      text-align: center;
      box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.3);
      max-width: 400px;
    }
    h1 {
     color: white;
      text-align: center;
    }
    button[type=submit] {
      background-color: #00b9c7;
      color: white;
      padding: 10px 20px;
      border: none;
      cursor: pointer;
      border-radius: 5px;
      width: 100%;
      font-size: 16px;
    }
  </style>
</head>
<body>
  <div class="container">
    <h1>Coin Operated Printing Kiosk</h1>
    <h2>Your File is uploaded successfully</h2>
    <p>File Name: {{ file_name }}</p>
    <form action="/" method="get">
      <button type="submit">Upload Another File</button>
    </form>
  </div>
</body>
</html>
"""

@app.route('/', methods=['GET', 'POST'])
def upload_file():
    error_message = None

    if request.method == 'POST':
        if 'file' not in request.files or request.files['file'].filename == '':
            error_message = 'Please select a file before clicking Upload.'
        else:
            file = request.files['file']

            # Check for allowed file extensions
            allowed_extensions = {'.pdf', '.xls', '.xlsx', '.doc', '.docx'}
            file_ext = os.path.splitext(file.filename)[1].lower()
            if file_ext not in allowed_extensions:
                error_message = 'File type not allowed'
            else:
                # Replace white spaces with underscores in the filename
                filename = file.filename.replace(" ", "_")
                
                # Save the file with the modified filename
                try:
                    file.save(os.path.join(app.config['UPLOAD_FOLDER'], filename))
                    return make_response(render_template_string(uploaded_template, file_name=filename), 200)
                except Exception as e:
                    error_message = f"Error saving file: {str(e)}"

    return make_response(render_template_string(upload_template, error_message=error_message), 200)

def get_ip_address():
    s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    try:
        s.connect(('8.8.8.8', 80))
        IP = s.getsockname()[0]
    except Exception:
        IP = '127.0.0.1'
    finally:
        s.close()
    return IP

def save_ip_address(ip_address):
    with open(ip_address_file, 'w') as file:
        file.write(ip_address)

if __name__ == '__main__':
    ip_address = get_ip_address()
    full_address = f"http://{ip_address}:5000"
    save_ip_address(full_address)
    print(f"Server is running on {full_address}/")
    app.run(host='0.0.0.0', port=5000)
