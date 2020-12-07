import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from 'src/app/Models/product';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  apiUrl = environment.baseUrl;

  constructor(private httpClient: HttpClient) {
   }

  GetProductList(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(`${this.apiUrl}product/${'getallProduct'}`);
  }

  GetProductDetailById(productId: string): Observable<any> {
    return this.httpClient.get(`${this.apiUrl}product/getproductbyid/?productId=${productId}`);
  }

  Save(product: Product): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}product/saveproduct`, product);
  }

  Update(product: Product): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}product/updateproduct`, product);
  }
}
