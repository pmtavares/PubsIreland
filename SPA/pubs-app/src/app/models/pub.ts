import { ICity } from './city';

export interface IPub
{
    id: number;
    name: string;
    username: string;
    description: string;
    descriptionDetailed: string;
    address: string;
    cityId: string;
    city?: ICity;
    phoneNumber: string;
    website: string;
    imagePath: string;
    dateAdded: Date;
    dateFounded: Date;
}