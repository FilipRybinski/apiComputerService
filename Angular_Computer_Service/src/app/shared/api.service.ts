import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { from, Observable, of } from 'rxjs';
import { Order, OrderType } from './order.model';
import { registrationModel, registrationModelType } from './registration.model';
import { messageModel, messageModelType } from './message.model';
import { User, UserType } from './user.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private http: HttpClient) {}
  postRegistration(data: registrationModel): Observable<registrationModel> {
    return this.http
      .post<registrationModel>(
        'https://localhost:7069/api/registration_order',
        data
      )
      .pipe(
        map((res: registrationModel) => {
          return res;
        })
      );
  }
  getRegistration(): Observable<registrationModel[]> {
    return this.http
      .get<registrationModelType[]>(
        'https://localhost:7069/api/registration_order'
      )
      .pipe(
        map(
          (
            registrations: {
              id: number;
              firstName: string;
              lastName: string;
              email: string;
              model_type: string;
              des_of_problem: string;
              des_of_demage: string;
            }[]
          ) =>
            registrations.map((registration) => {
              return new registrationModel(
                registration.id,
                registration.firstName,
                registration.lastName,
                registration.email,
                registration.model_type,
                registration.des_of_problem,
                registration.des_of_demage
              );
            })
        )
      );
  }
  deleteRegistration(id: number): Observable<Order> {
    return this.http
      .delete<Order>('https://localhost:7069/api/orders/' + id)
      .pipe(
        map((res: Order) => {
          return res;
        })
      );
  }
  updateRegistration(data: Order, id: number): Observable<Order> {
    return this.http
      .put<Order>('https://localhost:7069/api/orders/' + id, data)
      .pipe(
        map((res: Order) => {
          return res;
        })
      );
  }
  getOrder(): Observable<Order[]> {
    return this.http.get<OrderType[]>('https://localhost:7069/api/orders').pipe(
      map(
        (
          orders: {
            id: number;
            accept_date: Date;
            description: string;
            completed: boolean;
            email: string;
            wycena: number;
            date_collect: Date;
          }[]
        ) =>
          orders.map((order) => {
            return new Order(
              order.id,
              order.accept_date,
              order.description,
              order.completed,
              order.email,
              order.wycena,
              order.date_collect
            );
          })
      )
    );
  }
  deleteRegistration_form_client(id: number): Observable<registrationModel> {
    return this.http
      .delete<registrationModel>(
        'https://localhost:7069/api/registration_order/' + id
      )
      .pipe(
        map((res: registrationModel) => {
          return res;
        })
      );
  }
  postRegistrationOrder(data: Order): Observable<Order> {
    return this.http
      .post<Order>('https://localhost:7069/api/orders', data)
      .pipe(
        map((res: Order) => {
          return res;
        })
      );
  }
  postMessage(data: messageModel): Observable<messageModel> {
    return this.http
      .post<messageModel>('https://localhost:7069/api/message', data)
      .pipe(
        map((res: messageModel) => {
          return res;
        })
      );
  }
  getMessage(): Observable<messageModel[]> {
    return this.http
      .get<messageModelType[]>('https://localhost:7069/api/message')
      .pipe(
        map(
          (
            messages: {
              id: number;
              firstName: string;
              lastName: string;
              email: string;
              message: string;
            }[]
          ) =>
            messages.map((message) => {
              return new messageModel(
                message.id,
                message.firstName,
                message.lastName,
                message.email,
                message.message
              );
            })
        )
      );
  }
  deleteMessage(id: number): Observable<messageModel> {
    return this.http
      .delete<messageModel>('https://localhost:7069/api/message/' + id)
      .pipe(
        map((res: messageModel) => {
          return res;
        })
      );
  }
}
