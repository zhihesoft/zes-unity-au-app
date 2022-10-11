import "reflect-metadata";
import { container } from "tsyringe";
import { App, HttpConnector } from "zes-unity-jslib";
import { Root } from "./lib/root";

export const i18n = App.i18n;
App.container = container;
App.bootstrap(Root, "root");

const http = new HttpConnector("http://ip.jsontest.com/");

async function getbaidu() {
    const ret = await http.get("/");
    console.log(JSON.stringify(ret));
}

getbaidu();

// function wait(): Promise<void> {
//     return new Promise(resolve => {
//         setTimeout(() => {
//             resolve();
//         }, 1000);
//     })

// }

// let watiCount = 0;

// export function i18n(id: number): string {
//     return `id is ${id}`;
// }

// export async function testFunc() {
//     while (watiCount >= 0) {
//         await wait();
//         console.log(`wait ...${watiCount}`);
//         watiCount++;
//     }
// }



