from flask import Flask, request, jsonify

app = Flask(__name__)

@app.route('/post_gaze', methods=['POST'])
def post_gaze():
    data = request.json
    gaze_position = data.get('gaze_position', {})
    print(f"Received gaze position: {gaze_position}")
    return jsonify({"status": "success", "received": gaze_position}), 200

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
