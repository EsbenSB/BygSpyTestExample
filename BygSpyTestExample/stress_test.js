import http from 'k6/http';
import { sleep, check } from 'k6';

let testPassed = true;

export let options = {
    stages: [
        { duration: '10s', target: 1 },  // 10 seconds duration with 1 VU
        { duration: '10s', target: 1 },  // Another 10 seconds duration with 1 VU
        { duration: '10s', target: 0 }   // 10 seconds duration with 0 VU (ramp down)
    ],
    thresholds: {
        http_req_duration: ['p(01)<5000'],
        http_req_failed: ['rate<0.01']
    }
};

export default function () {
    const baseUrl = 'https://test-api.k6.io/public/crocodiles/';

    const res = http.get(baseUrl);

    const checkRes = check(res, {
        'status is 200': (r) => r.status === 200,
    });

    if (!checkRes) {
        testPassed = false;
    }

    sleep(Math.random() * 3);
}
