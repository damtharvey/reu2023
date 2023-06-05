# TREU 2023

## Note: Due to formatting inconsistencies, these notebooks are meant to be run with Jupyter Notebook and not Google Colab. If you run them with Google Colab, the functionality will be the same, but the formatting may not. You may also need to figure out a way to load the required images in Colab. See below for instructions on how to install and run Jupyter Notebook with Anaconda or Miniconda.

# Installing Anaconda: 
We recommend using Anaconda or Miniconda to manage your Python environments.
The setup for Anaconda and Miniconda will essentially be the same. Look here: https://www.educative.io/answers/anaconda-vs-miniconda to read about the differences between Anaconda and Miniconda

## Installation steps
1. Download Anaconda installer for your system at https://www.anaconda.com/, or Miniconda at https://docs.conda.io/en/latest/miniconda.html.
2. Begin Installation Process:
- Linux/Unix: Open the terminal and run: `bash Anaconda-latest-Linux-x86_64.sh` or `bash Miniconda3-latest-MacOSX-x86_64.sh` as appropriate. You may need to enable execution first by running `chmod +x Anaconda-latest-Linux-x86_64.sh` or `chmod +x Miniconda3-latest-MacOSX-x86_64.sh`.
- Windows: Run the .exe installer
- macOS: Open the .pkg file
3. Follow the prompts on the screen
4. Verify your installation of conda by opening the terminal (or Anaconda Prompt on Windows) and running `conda list`. A list of installed packages should appear if it is installed correctly. Note: For macOS and Linux.Unix, you can verify in the terminal, but you will have to close and open your terminal again for changes to take effect.
5. To create an environment, use the command: `conda create -n environment_name`, where `environment_name` is any name you want to name your environment. Then activate your environment with `conda activate environment_name`.
6. To install Jupyter, with your environment activated, use the command: `conda install jupyter`
7. To open Jupyter Notebook, use the command: `jupyter notebook`

## Installing Miniconda to CHPC:
1. Open new terminal on your machine and connect to CHPC using command: `ssh [your_uid]@notchpeak.chpc.utah.edu`. The password is the same as for your Canvas account.
2. Download Miniconda installer:

```[u1111111@notchpeak1:~]$ wget https://repo.continuum.io/miniconda/Miniconda3-latest-Linux-x86_64.sh```

3. Run the installer:

```[u1111111@notchpeak1:~]$ bash ./Miniconda3-latest-Linux-x86_64.sh -b -p $HOME/software/pkg/miniconda3 -s```

4. Create an user environment module. First create a directory where the user environment module hierarchy will reside, and then copy our miniconda module file to this directory.

```[u1111111@notchpeak1:~]$ mkdir -p $HOME/MyModules/miniconda3```

```[u1111111@notchpeak1:~]$ cp /uufs/chpc.utah.edu/sys/installdir/python/modules/miniconda3/latest.lua $HOME/MyModules/miniconda3```

5. Load the user space miniconda module.

```[u1111111@notchpeak1:~]$ module use $HOME/MyModules```

```[u1111111@notchpeak1:~]$ module load miniconda3/latest```

6. Verify your installation of conda by running `conda list`.

7. To create an environment, use the command: `conda create -n environment_name`, where `environment_name` is any name you want to name your environment. 

8. Now initialize conda by typing `conda init --all`. After you are done, the session can be closed. Open another terminal within CHPC to activate your conda and install jupyter as described below. 

9. Then activate your environment with `conda activate environment_name`.

8. To install Jupyter, with your environment activated, use the command: `conda install jupyter`

9. Don't forget to clone this repository (if you haven't done it before)

```
(base) [u1111111@notchpeak1:~]$ git clone https://github.com/damtharvey/reu2023.git
```

10. Feel free to close this terminal after you are done.

# Installing Packages
**Python should already be installed in any environments you make with `conda`**. To install it manually, or to change the version, activate your environment and run `conda install python=version`, where `version` is the Python version you want to install, e.g. `3.10`. The material in this repository assumes you have at least version `3.10`.

Packages can be installed in your active envrionment using `conda install package` or `pip install package`. `pip` tends to have more packages available than `conda`.

For more information about conda environments, how to create and modify them, and what they can be useful for follow these links: 
 - https://conda.io/projects/conda/en/latest/user-guide/tasks/manage-environments.html
 - https://www.freecodecamp.org/news/why-you-need-python-environments-and-how-to-manage-them-with-conda-85f155f4353c/

# Using Jupyter Notebooks Remotely
You can use your local browser to view a Jupyter Notebook on any machine you have access to, such as your own GPU server.

On the remote server, with your environment activated,
```
jupyter notebook --no-browser --port=8080
```
This should give your some http links. Copy any one of those links. You can change the port number from 8080 if you prefer.

Then, on your local machine, e.g. your laptop, run
```
ssh -L 8080:localhost:8080 yourname@remoteserver
```
where `yourname` is your user name and `remoteserver` is the host name of the remote server.

Then, open a web browser and paste the link that you copied from before.

If you do not have a remote machine or GPU on your machine, you can use CHPC (super-computer of the University of Utah).

## Using Jupyter Notebooks on CHPC
1. Follow the instructions on Miniconda Installation for CHPC (if you haven't done it yet on CHPC).

2. Using your web-browser on the local machine open new window with the following address:
```
https://ondemand.chpc.utah.edu
```

3. Log in using your Username and Password.

4. Now you are on CHPC. Choose Jupyter among all the Pinned Apps

5. Create a Notebook, choose account and partition so, that it will contain "gpu" in both names. Choose Advanced Options - GPU-type [any] and click to launch

6. After a successful start connect to the Notebook, choose the Notebook you want to launch

7. After laucnh, in widgets go to `Kernel` -> `change Kernel` -> Python (your env)

8. Enjoy! 
