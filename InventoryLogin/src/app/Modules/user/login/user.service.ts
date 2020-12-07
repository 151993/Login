import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/Models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl = environment.baseUrl;
  constructor(private httpClient: HttpClient) { }


  Login(userName: string, password: string): Observable<any> {
    return this.httpClient.get(this.apiUrl + 'user/login' + '?userName=' + userName + '&password=' + password);
  }

  Save(user: User): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}user/AddUser`, user);
  }


}
