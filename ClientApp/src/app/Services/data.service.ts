import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {PatientModel} from "../Models/PatientModel";
import {PatientResult} from "../Models/PatientResult";
import {Departament} from "../Models/Departament";

@Injectable()
export class DataService {

  constructor(private http: HttpClient) { }

  Calculate = (patient: PatientModel) =>
    this.http.post<PatientResult>('/api/Calculate', patient)

  GetDepartaments = () =>
    this.http.get<Departament[]>('api/GetDepartaments')
}
