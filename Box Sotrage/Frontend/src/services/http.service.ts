import { Injectable } from '@angular/core';
import axios from 'axios';

export const customAxios = axios.create({
  baseURL: 'http://localhost:5017'
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  async getProducts(){
    const httpResponse = await customAxios.get<any>('product');
    return httpResponse.data;
  }
}
