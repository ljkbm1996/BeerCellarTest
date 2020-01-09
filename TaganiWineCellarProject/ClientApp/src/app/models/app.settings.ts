import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';

@Injectable()
export class AppSettings {
    API_BASE_URL = environment.baseUrl;
}
